@ECHO OFF
ECHO Demo Automation Executed Started.
set testcategory=LinkedInLogin
set debugPath=C:\Users\Haris Khalid\source\repos\SoftwareTesting_Selenium\SoftwareTesting_Selenium\bin\Debug\

call "C:\Program Files (x86)\Microsoft Visual Studio\2019\Community\Common7\Tools\VsDevCmd.bat"
VSTest.Console.exe "%debugPath%SoftwareTesting_Selenium.dll" /TestCaseFilter:"TestCategory=%testcategory%" /Logger:"trx;"

cd %debugPath%
TrxToHTML.exe "C:\Users\Haris Khalid\source\repos\SoftwareTesting_Selenium\SoftwareTesting_Selenium\bin\Debug\TestResults"

PAUSE