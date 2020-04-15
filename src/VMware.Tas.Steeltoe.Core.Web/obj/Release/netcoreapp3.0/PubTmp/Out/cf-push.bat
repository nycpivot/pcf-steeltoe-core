cf target -s tas-steeltoe-core
pause
@cls

cf delete tas-steeltoe-core-web -r -f
pause
@cls

cf push
pause
@cls