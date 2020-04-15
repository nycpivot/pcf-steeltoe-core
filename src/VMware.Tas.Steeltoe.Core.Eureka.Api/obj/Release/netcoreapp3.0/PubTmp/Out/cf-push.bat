cf target -s pcf-steeltoe
pause
@cls

cf unbind-service pcf-steeltoe-core-eureka-api pcf-service-registry
pause
@cls

cf delete pcf-steeltoe-core-eureka-api -r -f
pause
@cls

cf push
pause
@cls