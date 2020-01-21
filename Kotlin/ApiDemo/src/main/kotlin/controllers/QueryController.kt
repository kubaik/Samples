package teste.controllers

import kotliquery.queryOf
import kotliquery.sessionOf
import kotliquery.using
import org.springframework.web.bind.annotation.GetMapping
import org.springframework.web.bind.annotation.RestController
import teste.models.Cliente
import teste.models.toCliente
import teste.models.toClienteFunc

@RestController
class QueryController {

    @GetMapping("/query/simple")
    fun Simple(): List<Cliente> {
        val data = using(sessionOf("jdbc:postgresql://localhost:5432/teste", "postgres", "123456")) { session ->
            val query = queryOf("select * from cliente where id = 1")
//                .map { row ->
//                    Cliente(
//                        id = row.int("id"),
//                        cpf = row.string("cpf"),
//                        nome = row.string("nome"),
//                        rg = row.string("rg")
//                    )
//                }
//                .map(toCliente)
                .map(::toClienteFunc)
                .asList
            session.run(query)
        }
        return data
    }
}