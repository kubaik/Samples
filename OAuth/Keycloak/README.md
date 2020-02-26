# Hydra

https://www.keycloak.org/

## Docker

```bash
docker run -d --name keycloak -p 8080:8080 -e KEYCLOAK_USER=admin -e KEYCLOAK_PASSWORD=123456 jboss/keycloak
```

## Hosted

```bash
./standalone.sh
./standalone.sh -Djboss.socket.binding.port-offset=100 -b 0.0.0.0
```
