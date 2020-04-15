cf target -s tas-steeltoe-core

cf create-service p-config-server standard tas-config-server -c config.json
cf create-service p-service-registry standard tas-service-registry
cf create-service p-circuit-breaker-dashboard standard tas-circuit-breaker-dashboard
cf create-service p-redis shared-vm tas-redis
cf create-service p-identity pivot-mjames tas-sso

cf cups tas-cups-sqlserver-products -p '{\"uid\":\"nycpivot\",\"pw\":\"P@$$w0rd#01\",\"uri\":\"sqlserver://saffron.arvixe.com:1433;databaseName=PivotalProducts\"}'
cf cups tas-cups-database -p '{\"provider\":\"CustomProvider\",\"server\":\"CustomServer\",\"port\":\"1433\",\"database\":\"CustomDatabase\",\"userid\":\"jdoe\",\"password\":\"password\"}'
pause