docker pull hyness/spring-cloud-config-server
pause

docker run --name local-config-server -p 8888:8888 -d -e SPRING_CLOUD_CONFIG_SERVER_GIT_URI=https://github.com/nycpivot/pcf-config-server-app-settings hyness/spring-cloud-config-server
pause

docker pull mayan31370/spring-eureka
pause

docker run -d --name local-service-registry -p 8761:8080/tcp mayan31370/spring-eureka
pause