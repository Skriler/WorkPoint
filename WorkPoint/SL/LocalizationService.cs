namespace WorkPoint.SL
{
    public static class LocalizationService
    {
        private static Dictionary<string, string> englishToUkrainianDictionary;

        static LocalizationService()
        {
            englishToUkrainianDictionary = new Dictionary<string, string>()
            {
                { "Salary", "Заробітна плата" },
                { "IsRemote", "Віддалено" },
                { "HasOfficeInZaporizhzhia", "Має офіс у Запоріжжі" },
                { "RequiredExperience", "Необхідний досвід" },
                { "IsHighEducationNeeded", "Необхідність вищої освіти" },
                { "IsB2EnglishLevelNeeded", "Чи потрібен рівень англійської B2" },
                { "Teamwork", "Робота в команді" },
                { "Responsibility", "Відповідальність" },
                { "Punctuality", "Пунктуальність" },
                { "Social", "Вміння спілкуватись" },
                { "Analytical", "Аналітичний" },
                { "Business", "Бізнес" },
                { "Attention", "Уважний" },
                { "Planning", "Планування" },
                { "QuickLearner", "Швидко навчаюся" },
                { "CriticalThinking", "Критичне мислення" },
                { "Statistics", "Статистика" },
                { "ContentPromotion", "Просування контенту" },
                { "HTML", "HTML" },
                { "CSS", "CSS" },
                { "Bootstrap", "Bootstrap" },
                { "PHP", "PHP" },
                { "JS", "JS" },
                { "React", "React" },
                { "NodeJS", "NodeJS" },
                { "Vue", "Vue" },
                { "Vuex", "Vuex" },
                { "RestAPI", "REST API" },
                { "Python", "Python" },
                { "PyTest", "PyTest" },
                { "Mocha", "Mocha" },
                { "UnitTesting", "UnitTesting" },
                { "TypeScript", "TypeScript" },
                { "CPlusPlus", "C++" },
                { "CSharp", "C#" },
                { "DOTNET", "DOTNET" },
                { "HTTP", "HTTP" },
                { "Dart", "Dart" },
                { "Flutter", "Flutter" },
                { "Swift", "Swift" },
                { "OneC", "1C" },
                { "WordPress", "WordPress" },
                { "PrinciplesOOP", "Принципи ООП" },
                { "SolidPrinciples", "SOLID" },
                { "Multithreading", "Многопоточность" },
                { "MYSQL", "MYSQL" },
                { "PostgreSQL", "PostgreSQL" },
                { "MongoDB", "MongoDB" },
                { "Redis", "Redis" },
                { "NoSQL", "NoSQL" },
                { "Oracle", "Oracle" },
                { "MSSQL", "MSSQL" },
                { "Word", "Word" },
                { "Excel", "Excel" },
                { "Access", "Access" },
                { "Powerpoint", "Powerpoint" },
                { "Windows", "Windows" },
                { "Mac", "Mac" },
                { "Linux", "Linux" },
                { "VSCO", "VSCO" },
                { "Snapseed", "Snapseed" },
                { "Lightroom", "Lightroom" },
                { "Photoshop", "Photoshop" },
                { "Git", "Git" },
                { "GoogleAnalytics", "Google Analytics" },
                { "FacebookAnalytics", "Facebook Analytics" },
                { "NetworkProtocols", "Network Protocols" },
                { "ComputerNetworks", "Computer Networks" },
                { "MaintainingSoftware", "Maintaining Software" },
                { "NeatpeakSpider", "Neatpeak Spider" },
                { "Ahrefs", "Ahrefs" }
            };
        }

        public static Dictionary<string, bool> GetLocalizedUkrainianDictionary(Dictionary<string, bool> englishDictionary)
        {
            var ukrainianDictionary = new Dictionary<string, bool>();

            foreach (var pkv in englishDictionary)
            {
                if (!englishToUkrainianDictionary.ContainsKey(pkv.Key))
                    continue;

                ukrainianDictionary.Add(
                    englishToUkrainianDictionary[pkv.Key], 
                    pkv.Value
                    );
            }

            return ukrainianDictionary;
        }
    }
}
