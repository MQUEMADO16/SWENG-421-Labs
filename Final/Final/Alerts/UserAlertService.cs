using System;
using System.Collections.Generic;
using Final.Core;
using Final.Models;
using Final.Alerts.Decorators;

namespace Final.Alerts
{
    internal class UserAlertService : ITradeObserver
    {
        private readonly List<AlertRule> _activeRules;
        private readonly MarketDataCache _targetCache;

        // The event the WinForms UI will listen to
        public event Action<string>? OnAlertGenerated;

        public UserAlertService(MarketDataCache cache)
        {
            _activeRules = new List<AlertRule>();
            _targetCache = cache;

            // Subscribe this service to the cache immediately upon creation
            _targetCache.attachObserver(this);
        }

        public void addRule(AlertRule rule)
        {
            _activeRules.Add(rule);
        }

        public void update(TradeDataPoint data)
        {
            foreach (var rule in _activeRules)
            {
                // Check if this incoming tick for a stock we have a rule for?
                if (rule.TargetTicker == data.Ticker)
                {
                    // FILTER PATTERN: Pass the live data to the filter
                    if (rule.IsTriggered(data))
                    {
                        // DECORATOR PATTERN: Start building the alert wrap
                        // Initialize the core component with the exact boundary thresholds
                        IAlert finalAlert = new PriceAlert(data, rule.LowThreshold, rule.HighThreshold);

                        // Wrap it in a Timestamp if the UI flag is true
                        if (rule.IncludeTimestamp)
                        {
                            finalAlert = new TimeStampAlert(finalAlert, data);
                        }

                        // Wrap it in a Percent Change if the UI flag is true
                        if (rule.IncludePercentChange)
                        {
                            finalAlert = new PercentChangeAlert(finalAlert, data);
                        }

                        // Execute the decorator chain and broadcast the final string
                        // Calling sendAlert() to pull the fully built string
                        OnAlertGenerated?.Invoke(finalAlert.sendAlert());
                    }
                }
            }
        }
    }
}