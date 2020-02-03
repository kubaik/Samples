# Kong Api Gateway for Micro Services

Compose base: <https://github.com/Kong/docker-kong/tree/master/compose>  
Kong admin: <https://hub.docker.com/r/pgbi/kong-dashboard>  

```bash
cd compose
./up
```

```bash
curl -i -X POST \
  --url http://localhost:8001/services/ \
  --data 'name=demo-service' \
  --data 'url=http://192.168.1.6:5001'

curl -i -X POST \
  --url http://localhost:8001/services/demo-service/routes \
  --data 'hosts[]=localhost' \  
  --data 'paths[]=/actors/'

```