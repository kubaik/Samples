package com.company;

import com.company.domain.Cliente;
import com.company.repository.ClienteJpaDAO;

import java.util.List;

public class Main {

    public static void main(String[] args) {
        // write your code here
        System.out.println("Hello Hibernate!");

//        insertCliente();
        listClientes();
    }

    private static void listClientes() {
        List<Cliente> clientes = ClienteJpaDAO.getInstance().findAll();
        for (Cliente c : clientes) {
            System.out.println(c.getId() + " - " + c.getNome());
        }
    }

    private static void insertCliente() {
        Cliente cli = new Cliente();
        cli.setId(1);
        cli.setCpf("07072034900");
        cli.setRg("5213784");
        cli.setNome("Fábio Monteiro Naspolini");
        ClienteJpaDAO.getInstance().merge(cli);
        System.out.println("Cliente inserido " + cli.getId());
    }
}
