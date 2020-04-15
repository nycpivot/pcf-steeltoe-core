cf target -s tas-steeltoe-core
pause
@cls

cf unbind-service tas-steeltoe-core-eureka-api tas-service-registry
pause
@cls

cf delete tas-steeltoe-core-eureka-api -r -f
pause
@cls

cf push
pause
@cls