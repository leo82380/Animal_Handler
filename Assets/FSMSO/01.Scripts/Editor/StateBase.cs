public static class StateBase
{
    public static string stateScriptTemplate = 
@"using System.Collections;
using UnityEngine;

[CreateAssetMenu(menuName = ""State/{0}"")]
public class {0}State : {4}State
{{
    {1}
    {2}
    {3}
}}";
    
    public static string GenerateMethod(string methodName)
    {
        return
$@"public override void {methodName}()
    {{
        base.{methodName}();
    }}";
    }
}