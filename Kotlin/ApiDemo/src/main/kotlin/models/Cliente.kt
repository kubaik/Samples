package teste.models

import kotliquery.Row

data class Cliente(
    var id: Int,
    val cpf: String,
    val nome: String,
    val rg: String
)

val toCliente: (Row) -> Cliente = { row ->
    Cliente(
        id = row.int("id"),
        cpf = row.string("cpf"),
        nome = row.string("nome"),
        rg = row.string("rg")
    )
}

fun toClienteFunc(row: Row): Cliente {
    return Cliente(
        id = row.int("id"),
        cpf = row.string("cpf"),
        nome = row.string("nome"),
        rg = row.string("rg")
    )
}