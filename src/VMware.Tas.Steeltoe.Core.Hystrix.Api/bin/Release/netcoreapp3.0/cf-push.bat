cf target -s tas-steeltoe-core
pause
@cls

cf unbind-service tas-steeltoe-core-hystrix-api tas-service-registry
cf unbind-service tas-steeltoe-core-hystrix-api tas-redis
pause
@cls

cf delete tas-steeltoe-core-hystrix-api -r -f
pause
@cls

cf push
pause
@cls