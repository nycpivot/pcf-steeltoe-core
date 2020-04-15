cf target -s tas-steeltoe-core
pause
@cls

cf unbind-service tas-steeltoe-core-web tas-config-server
cf unbind-service tas-steeltoe-core-eureka-api tas-service-registry
cf unbind-service tas-steeltoe-core-hystrix-api tas-service-registry
cf unbind-service tas-steeltoe-core-hystrix-fallback-api tas-service-registry
cf unbind-service tas-steeltoe-core-web tas-service-registry
cf unbind-service tas-steeltoe-core-web tas-circuit-breaker-dashboard
cf unbind-service tas-steeltoe-core-hystrix-api tas-redis
cf unbind-service tas-steeltoe-core-security tas-sso
cf unbind-service tas-steeltoe-core-hystrix-fallback-api tas-cups-sqlserver-products
cf unbind-service tas-steeltoe-core-web tas-cups-database
pause
@cls

cf delete-service tas-config-server -f
cf delete-service tas-service-registry -f
cf delete-service tas-circuit-breaker-dashboard -f
cf delete-service tas-redis -f
cf delete-service tas-sso -f
cf delete-service tas-cups-sqlserver-products -f
cf delete-service tas-cups-database -f
pause
@cls

cf delete tas-steeltoe-core-eureka-api -r -f
cf delete tas-steeltoe-core-hystrix-api -r -f
cf delete tas-steeltoe-core-hystrix-fallback-api -r -f
cf delete tas-steeltoe-core-management -r -f
cf delete tas-steeltoe-core-security -r -f
cf delete tas-steeltoe-core-web -r -f
pause
@cls