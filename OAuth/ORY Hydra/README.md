# Hydra

https://www.ory.sh/run-oauth2-server-open-source-api-security/


export SECRETS_SYSTEM=$(export LC_CTYPE=C; cat /dev/urandom | tr -dc 'a-zA-Z0-9' | fold -w 32 | head -n 1)
export DSN=postgres://hydra:secret@ory-hydra-example--postgres:5432/hydra?sslmode=disable