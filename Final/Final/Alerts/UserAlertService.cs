using System;
using System.Collections.Generic;
using Final.Core;
using Final.Models;
using Final.Alerts.Decorators;

namespace Final.Alerts
{
    public class UserAlertService : ITradeObserver
    {
        private readonly List<AlertRule> _activeRules;
        private readonly MarketDataCache _targetCache;

        private readonly object _rulesLock = new object();

        public event Action<AlertRule, string>? onAlertGenerated;

        public UserAlertService(MarketDataCache cache)
        {
            _activeRules = new List<AlertRule>();
            _targetCache = cache;
            _targetCache.attachObserver(this);
        }

        public void addRule(AlertRule rule)
        {
            // Lock when modifying from the UI
            lock (_rulesLock)
            {
                _activeRules.Add(rule);
            }
        }

        public void update(TradeDataPoint data)
        {
            List<AlertRule> rulesSnapshot;
            lock (_rulesLock)
            {
                rulesSnapshot = new List<AlertRule>(_activeRules);
            }

            foreach (var rule in rulesSnapshot)
            {
                if (!rule.IsSuspended && rule.TargetTicker == data.Ticker)
                {
                    if (rule.IsTriggered(data))
                    {
                        rule.IsSuspended = true;

                        IAlert finalAlert = new PriceAlert(data, rule.LowThreshold, rule.HighThreshold);
                        if (rule.IncludeTimestamp) finalAlert = new TimeStampAlert(finalAlert, data);
                        if (rule.IncludePercentChange) finalAlert = new PercentChangeAlert(finalAlert, data);

                        rule.LastAlertMessage = finalAlert.sendAlert();
                        rule.LastTriggerTime = DateTime.Now.ToString("HH:mm:ss.fff");

                        onAlertGenerated?.Invoke(rule, rule.LastAlertMessage);
                    }
                }
            }
        }

        public MarketDataCache getTargetCache()
        {
            return _targetCache;
        }

        public int getRuleCount()
        {
            lock (_rulesLock) { return _activeRules.Count; }
        }

        public List<AlertRule> getRules()
        {
            lock (_rulesLock)
            {
                return new List<AlertRule>(_activeRules);
            }
        }

        public void acknowledgeRule(Guid ruleId)
        {
            lock (_rulesLock)
            {
                var rule = _activeRules.Find(r => r.RuleId == ruleId);
                if (rule != null)
                {
                    rule.IsSuspended = false;
                }
            }
        }
        public void removeRule(Guid ruleId)
        {
            lock (_rulesLock)
            {
                _activeRules.RemoveAll(r => r.RuleId == ruleId);
            }
        }
    }
}