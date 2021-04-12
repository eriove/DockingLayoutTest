using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using Moq;
using Shouldly;
using AvalonDock;
using AvalonDock.Layout;
using Xunit;
using Xunit.Abstractions;

namespace DockingLayoutTest
{
    public class NavigationServiceTests
    {
        private readonly Grid _leftSideContent1 = new Grid();
        private readonly Grid _leftSideContent2 = new Grid();
        private readonly Grid _rightSideContent1 = new Grid();
        private readonly Grid _rightSideContent2 = new Grid();
        private readonly Grid _topContent1 = new Grid();
        private readonly Grid _topContent2 = new Grid();
        private readonly Grid _bottomContent1 = new Grid();
        private readonly Grid _bottomContent2 = new Grid();

        private readonly Window _window = new Window();
        public NavigationServiceTests()
        {
            Grid actualContent = new Grid();
            var layoutRoot = new LayoutRoot()
            {
                RootPanel = new LayoutPanel()
                {
                    Children = {
                        new LayoutAnchorablePaneGroup()
                        {
                            Children =
                            {
                                new LayoutAnchorablePane()
                                {
                                    Name = "RootPane",
                                    Children =
                                    {
                                        new LayoutAnchorable()
                                        {
                                            Content = actualContent
                                        }
                                    }
                                }
                            }
                    }
                        }
                },
                LeftSide = new LayoutAnchorSide()
                {
                    Children =
                    {
                        new LayoutAnchorGroup()
                        {
                            Children =
                            {
                                new LayoutAnchorable()
                                {
                                    Content = _leftSideContent1
                                },
                                new LayoutAnchorable()
                                {
                                    Content = _leftSideContent2
                                }
                            }
                        }
                    }
                },
                RightSide = new LayoutAnchorSide()
                {
                    Children =
                    {
                        new LayoutAnchorGroup()
                        {
                            Children =
                            {
                                new LayoutAnchorable()
                                {
                                    Content = _rightSideContent1
                                },
                                new LayoutAnchorable()
                                {
                                    Content = _rightSideContent2
                                }
                            }
                        }
                    }
                },
                TopSide = new LayoutAnchorSide()
                {
                    Children =
                    {
                        new LayoutAnchorGroup()
                        {
                            Children =
                            {
                                new LayoutAnchorable()
                                {
                                    Content = _topContent1
                                },
                                new LayoutAnchorable()
                                {
                                    Content = _topContent2
                                }
                            }
                        }
                    }
                },
                BottomSide = new LayoutAnchorSide()
                {
                    Children =
                    {
                        new LayoutAnchorGroup()
                        {
                            Children =
                            {
                                new LayoutAnchorable()
                                {
                                    Content = _bottomContent1
                                },
                                new LayoutAnchorable()
                                {
                                    Content = _bottomContent2
                                }
                            }
                        }
                    }
                }
            };
            var dockingManager = new DockingManager()
            {
                
            };
            dockingManager.Resources.MergedDictionaries.Clear();
            dockingManager.Layout = layoutRoot;
            //typeof(DockingManager).Assembly.Res
            CreateVisualTree(dockingManager);
        }

        private void CreateVisualTree(DockingManager element)
        {
            var grid = new Grid();
            grid.Children.Add(element);
            _window.Content = grid;
            // We need to open a window to get a visual tree, this is outside of the screen
            _window.Height = 1;
            _window.Width = 1;
            _window.Top = -100;
            _window.Left = -100;
            _window.ShowInTaskbar = false;
        }

        [WpfFact]
        public void ShouldRunConstructor()
        {

        }

        [WpfFact]
        public void ShouldRunConstructorAgain()
        {

        }
    }
}
