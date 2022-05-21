using OpenQA.Selenium;
using System.Collections.Generic;
using System.Threading;

namespace FitnessAppSeleniumTests.framework.config.basicmethods
{
    public class PaginationUtils
    {
        private const string HTML = "html";
        private const string NEXT_PAGE = "PagedList-skipToNext";
        private const string ACTIVE = "active";
        private const string CLASS = "class";
        private const string DISABLED = "disabled";
        private const string PAGINATION_LI = ".pagination li";

        private static IWebElement WholePage()
        {
            return SearchContextUtil.FindElement(By.TagName(HTML));
        }

        public static void GoToLastPage(By paginationContainerBy)
        {
            IWebElement paginationContainer = Config.GetDriver().FindElement(paginationContainerBy);
            while (HasViewNextPage(paginationContainer))
            {
                if (IsPaginationActive(paginationContainer))
                {
                    IList<IWebElement> elements = GetPaginationButtons(paginationContainer);
                    IWebElement penultimateElement = elements[elements.Count - 2];
                    if (ACTIVE.Equals(penultimateElement.GetAttribute(CLASS)))
                    {
                        GetLastPage(paginationContainer).Click();
                    }
                    else
                    {
                        penultimateElement.Click();
                    }
                }
            }
        }

        public static void GoToLastPage()
        {
            while (HasViewNextPage(WholePage()))
            {
                if (IsPaginationActive(WholePage()))
                {
                    IList<IWebElement> elements = GetPaginationButtons(WholePage());
                    IWebElement penultimateElement = elements[elements.Count - 2];
                    if (ACTIVE.Equals(penultimateElement.GetAttribute(CLASS)))
                    {
                        GetLastPage(WholePage()).Click();
                    }
                    else
                    {
                        penultimateElement.Click();
                    }
                }
            }
        }

        public static bool IsPaginationActive(IWebElement paginationContainer)
        {
            return GetPaginationButtons(paginationContainer).Count > 1;
        }

        private static IList<IWebElement> GetPaginationButtons(IWebElement paginationContainer)
        {
            IList<IWebElement> elements = paginationContainer.FindElements(By.CssSelector(PAGINATION_LI));
            IList<IWebElement> elements_enabled = new List<IWebElement>();

            foreach(IWebElement element in elements) {
                if (!element.GetAttribute(CLASS).Contains(DISABLED)) {
                    elements_enabled.Add(element);
                }
            }

            return elements_enabled;
        }

        private static IList<IWebElement> GetPaginationButtons()
        {
            IList<IWebElement> elements = SearchContextUtil.FindElement(By.TagName(HTML)).FindElements(By.CssSelector(PAGINATION_LI));
            IList<IWebElement> elements_enabled = new List<IWebElement>();

            foreach (IWebElement element in elements)
            {
                if (!element.GetAttribute(CLASS).Contains(DISABLED))
                {
                    elements_enabled.Add(element);
                }
            }

            return elements_enabled;
        }


        public static void GoBackToFirstPage()
        {
            GoBackToFirstPage(WholePage());
        }

        private static void GoBackToFirstPage(IWebElement paginationContainer)
        {
            if (IsPaginationActive(paginationContainer))
            {
                IWebElement firstPageBtn = SearchContextUtil.FindElements(By.CssSelector(PAGINATION_LI))[0];
                if (!ACTIVE.Equals(firstPageBtn.GetAttribute(CLASS)))
                {
                    firstPageBtn.Click();
                }
            }
        }

        public static void GoToNextPage()
        {
            GoToNextPage(WholePage());
        }

        private static void GoToNextPage(IWebElement paginationContainer)
        {
            GetNextPageButtons(paginationContainer)[0].Click();
        }

        private static IWebElement GetLastPage(IWebElement paginationContainer)
        {
            IList<IWebElement> nextPageButtons = GetNextPageButtons(paginationContainer);
            return nextPageButtons[nextPageButtons.Count - 1];
        }

        private static bool HasViewNextPage(IWebElement paginationContainer)
        {
            try
            {
                return GetNextPageButtons(paginationContainer).Count > 0;
            }
            catch (StaleElementReferenceException)
            {
                return false;
            }
        }

        public static bool HasViewNextPage()
        {
            return GetNextPageButtons().Count > 0;
        }

        private static IList<IWebElement> GetNextPageButtons(IWebElement paginationContainer)
        {
            IList<IWebElement> nextPageButtons = paginationContainer.FindElements(By.ClassName(NEXT_PAGE));
            IList<IWebElement> nextPageButtonsEnabled = new List<IWebElement>();

            foreach (IWebElement element in nextPageButtons) {
                if (!element.GetAttribute(CLASS).Contains(DISABLED)) {
                    nextPageButtonsEnabled.Add(element);
                }
            }
            
            return nextPageButtonsEnabled;
        }

        private static IList<IWebElement> GetNextPageButtons()
        {
            return GetNextPageButtons(WholePage());
        }
    }
}
