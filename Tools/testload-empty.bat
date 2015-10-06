@ECHO OFF
REM =======================================================================
REM EMPTY CALLS
REM =======================================================================

@ECHO Running in %~dp0

SET WEB_SITE=http://localhost:27334/
SET NB_LOOPS=%1
SET NB_CONCURRENT=%2
SET OUTPUT_HTML=results_empty_N%NB_LOOPS%_C%NB_CONCURRENT%.html
if exist %OUTPUT_HTML%-temp del %OUTPUT_HTML%-temp

echo ^<h1 style='color:red'^>Empty-Nancy-Sync (loops : %NB_LOOPS%, CONCURRENT: %NB_CONCURRENT%)^</h1^> >> %OUTPUT_HTML%-temp
ab.exe -n %NB_LOOPS% -c %NB_CONCURRENT% -S -q -w -d -H "accep:application/json"  %WEB_SITE%/nancy/sync/empty >> %OUTPUT_HTML%-temp

echo ^<h1 style='color:red'^>Empty-Nancy-Async (loops : %NB_LOOPS%, CONCURRENT: %NB_CONCURRENT%)^</h1^> >> %OUTPUT_HTML%-temp
ab.exe -n %NB_LOOPS% -c %NB_CONCURRENT% -S -q -w -d -H "accep:application/json" %WEB_SITE%/nancy/async/empty >> %OUTPUT_HTML%-temp

echo ^<h1 style='color:red'^>Empty-WebApi-Sync (loops : %NB_LOOPS%, CONCURRENT: %NB_CONCURRENT%)^</h1^> >> %OUTPUT_HTML%-temp
ab.exe -n %NB_LOOPS% -c %NB_CONCURRENT% -S -q -w -d -H "accep:application/json"  %WEB_SITE%/webapi/sync/empty >> %OUTPUT_HTML%-temp

echo ^<h1 style='color:red'^>Empty-WebApi-Async (loops : %NB_LOOPS%, CONCURRENT: %NB_CONCURRENT%)^</h1^> >> %OUTPUT_HTML%-temp
ab.exe -n %NB_LOOPS% -c %NB_CONCURRENT% -S -q -w -d -H "accep:application/json"  %WEB_SITE%/webapi/async/empty >> %OUTPUT_HTML%-temp





REM =======================================================================
REM CLEANING OUT
REM =======================================================================
if exist %OUTPUT_HTML% del %OUTPUT_HTML%
copy %OUTPUT_HTML%-temp %OUTPUT_HTML%
if exist %OUTPUT_HTML% del %OUTPUT_HTML%-temp

REM === then finish opening results file
%OUTPUT_HTML%
