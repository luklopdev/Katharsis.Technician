using Katharsis.Technician.Core;
using Prism.Ioc;
using Prism.Regions;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace Katharsis.Technician.Regions
{
    public class DependentViewRegionBehavior : RegionBehavior
    {

        private readonly IContainerExtension _container;

        private Dictionary<object, List<DependentViewInfo>> _dependentViewCache = new Dictionary<object, List<DependentViewInfo>>();

        public const string BEHAVIOR_KEY = nameof(DependentViewRegionBehavior);

        public DependentViewRegionBehavior(IContainerExtension container)
        {
            _container = container;
        }

        protected override void OnAttach()
        {
            Region.ActiveViews.CollectionChanged += ActiveViews_CollectionChanged;
        }

        private void ActiveViews_CollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            if(e.Action == NotifyCollectionChangedAction.Add)
            {
                foreach(var view in e.NewItems)
                {
                    var dependentViews = new List<DependentViewInfo>();

                    if (_dependentViewCache.ContainsKey(view))
                    {
                        dependentViews = _dependentViewCache[view];
                    }
                    else
                    {
                        var attributes = GetCustomAttributes<DependentViewAttribute>(view.GetType());

                        foreach (var attribute in attributes)
                        {
                            var info = CreateDependentViewInfo(attribute);
                            dependentViews.Add(info);
                        }

                        _dependentViewCache.Add(view, dependentViews);
                    }

                    bool firstTabItemSelected = false;
                    dependentViews.ForEach(item => 
                    {
                        Region.RegionManager.Regions[item.Region].Add(item.View);

                        if (!firstTabItemSelected)
                        {
                            if (item.View is TabItem tabItem)
                            {
                                tabItem.IsSelected = true;
                                firstTabItemSelected = true;
                            }
                        }
                    });
                }
            }
            else if(e.Action == NotifyCollectionChangedAction.Remove)
            {
                foreach(var oldView in e.OldItems)
                {
                    if (_dependentViewCache.ContainsKey(oldView))
                    {
                        var dependentViews = _dependentViewCache[oldView];
                        dependentViews.ForEach(item => Region.RegionManager.Regions[item.Region].Remove(item.View));

                        if (!ShouldKeepAlive(oldView))
                        {
                            _dependentViewCache.Remove(oldView);
                        }
                    }
                }
            }
        }

        private bool ShouldKeepAlive(object oldView)
        {
            var regionLifetime = GetViewOrDataContextLifetime(oldView);

            if (regionLifetime != null)
                return regionLifetime.KeepAlive;

            return true;
        }

        IRegionMemberLifetime GetViewOrDataContextLifetime(object view)
        {
            if(view is IRegionMemberLifetime regionLifetime)
            {
                return regionLifetime;
            }

            if(view is FrameworkElement frameworkElement)
            {
                return frameworkElement.DataContext as IRegionMemberLifetime;
            }

            return null;
        }

        DependentViewInfo CreateDependentViewInfo(DependentViewAttribute attribute)
        {
            var info = new DependentViewInfo();

            info.Region = attribute.Region;
            info.View = _container.Resolve(attribute.Type);

            return info;
        }

        private static IEnumerable<T> GetCustomAttributes<T>(Type type)
        {
            return type.GetCustomAttributes(typeof(T), true).OfType<T>();
        }
    }
}
