# ci-cd-dotnet

API mínima ASP.NET Core (.NET 8) desplegada automáticamente por Jenkins (ver repo `ci-cd-template`). Con CORS abierto, ya que la consume el front `ci-cd-react` desde el navegador.

| Endpoint | Respuesta |
|---|---|
| `GET /` | `dotnet-example OK` |
| `GET /products` | JSON con 3 productos |
| `GET /personas` | JSON con 3 personas (usado por `ci-cd-react`) |

Puertos: host **8083** → contenedor **8080**.

## Ejecutar local

```bash
docker build -t dotnet-example:test .
docker run -d --rm --name dotnet-example-test -p 8083:8080 dotnet-example:test
curl http://localhost:8083/personas
docker stop dotnet-example-test
```

## Despliegue

Un push a `main` dispara el job de Jenkins (`pollSCM`, ~1–2 min): build → deploy → smoke check.
