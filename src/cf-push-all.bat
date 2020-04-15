cf target -s tas-steeltoe-core
pause

cf push -p .\VMware.Tas.Steeltoe.Core.Eureka.Api\bin\Release\netcoreapp3.0\publish
cf push -p .\VMware.Tas.Steeltoe.Core.Hystrix.Api\bin\Release\netcoreapp3.0\publish
cf push -p .\VMware.Tas.Steeltoe.Core.Hystrix.Fallback.Api\bin\Release\netcoreapp3.0\publish
cf push -p .\VMware.Tas.Steeltoe.Core.Web\bin\Release\netcoreapp3.0\publish
cf push -p .\VMware.Tas.Steeltoe.Core.Management\bin\Release\netcoreapp3.0\publish
pause