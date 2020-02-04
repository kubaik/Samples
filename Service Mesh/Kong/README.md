# Kong Api Gateway for Micro Services

Compose base: <https://github.com/Kong/docker-kong/tree/master/compose>  
Kong admin: <https://hub.docker.com/r/pgbi/kong-dashboard>  

```bash
cd compose
./up

# Test to routing container to host
docker network create -d macvlan --subnet=192.168.0.0/24 --gateway=192.168.0.1 --aux-address="lnx-naspolini=192.168.0.108" -o parent=wlo1 host_link
docker network connect host_link kong_kong_1
docker exec -it kong_kong_1 /bin/sh
docker network disconnect host_link kong_kong_1 && docker network rm host_link

```

```bash
curl -i -X POST \
  --url http://localhost:8001/services/ \
  --data 'name=demo-service' \
  --data 'url=http://192.168.1.6:5001'

curl -i -X POST \
  --url http://localhost:8001/services/demo-service/routes \
  --data 'hosts[]=localhost' \  
  --data 'paths[]=/(?i)Actors/Api'

```