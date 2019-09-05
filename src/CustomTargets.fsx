open Fake

let testDirectory = getBuildParamOrDefault "buildMode" "Debug"
let nUnitToolPath = @"tools\NUnit.ConsoleRunner\tools\nunit3-console.exe"
let acceptanceTestPlayList = getBuildParamOrDefault "playList" ""
let nunitTestFormat = getBuildParamOrDefault "nunitTestFormat" "nunit2"

Target "Run Automation Suite Tests" (fun _ ->

    trace "Run Automation Suite Tests"
    
    let mutable shouldRunTests = false

    let testDlls = !! ("./**/bin/" + testDirectory + "/*-Automation-Suite.dll") 
    
    for testDll in testDlls do
        shouldRunTests <- true
    
    if shouldRunTests then
        testDlls |> Fake.Testing.NUnit3.NUnit3 (fun p ->
            {p with
                ToolPath = nUnitToolPath;
                StopOnError = false;
                Agents = Some 1;    
                Testlist = acceptanceTestPlayList;
                ResultSpecs = [("TestResult.xml;format=" + nunitTestFormat)];
                })
)
