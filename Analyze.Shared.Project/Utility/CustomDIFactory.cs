using Microsoft.Practices.Unity.Configuration;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Web;
using Unity;

namespace Analyze.Shared.Project.Utility
{
    public class CustomDIFactory
    {
        private static IUnityContainer _Container = new UnityContainer();

        static CustomDIFactory()
        {
            ExeConfigurationFileMap fileMap = new ExeConfigurationFileMap();
            fileMap.ExeConfigFilename = Path.Combine(AppDomain.CurrentDomain.BaseDirectory + "CfgFiles\\Unity.Config");
            Configuration configuration = ConfigurationManager.OpenMappedExeConfiguration(fileMap, ConfigurationUserLevel.None);
            UnityConfigurationSection section = (UnityConfigurationSection)configuration.GetSection
                (UnityConfigurationSection.SectionName);
            section.Configure(_Container, "AnalyzeContainer");
        }

        public static IUnityContainer GetContainer() 
        {
            return _Container;
        }
    }
}