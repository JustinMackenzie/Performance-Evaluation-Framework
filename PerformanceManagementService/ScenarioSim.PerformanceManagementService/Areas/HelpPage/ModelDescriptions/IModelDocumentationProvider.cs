using System;
using System.Reflection;

namespace ScenarioSim.PerformanceManagementService.Areas.HelpPage.ModelDescriptions
{
    public interface IModelDocumentationProvider
    {
        string GetDocumentation(MemberInfo member);

        string GetDocumentation(Type type);
    }
}