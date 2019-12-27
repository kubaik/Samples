import models.Endereco;

import javax.persistence.EntityManagerFactory;
import javax.persistence.Persistence;
import javax.persistence.criteria.CriteriaBuilder;
import java.util.List;

public class AppEntityManager {
    private EntityManagerFactory _entityManagerFactory;

    public void execute() {
        _entityManagerFactory = createEntityManagerFactory();
        listEnderecos();
        printOneEndereco();
        insertEndereco();
    }

    private void listEnderecos() {
        var em = _entityManagerFactory.createEntityManager();
        try {
            var builder = em.getCriteriaBuilder();
            var criteria = builder.createQuery(Endereco.class);
            criteria.from(Endereco.class);
            var result = em.createQuery(criteria).getResultList();
            System.out.println("Id  | Rua           | Cidade");
            for (var end : result) {
                System.out.println(String.format("%s | %s | %s", end.getCodigo(), end.getRua(), end.getCidade()));
            }
        } finally {
            em.close();
        }
        System.out.println("end of listEnderecos");
    }

    private void printOneEndereco() {
        var em = _entityManagerFactory.createEntityManager();
        try {
            var end = em.createQuery("from Endereco e where e.codigo = :codigo", Endereco.class)
                    .setParameter("codigo", 1)
                    .getSingleResult();

            System.out.println("Id  | Rua           | Cidade");
            System.out.println(String.format("%s | %s | %s", end.getCodigo(), end.getRua(), end.getCidade()));
        } finally {
            em.close();
        }
        System.out.println("end of printOneEndereco");
    }

    private void insertEndereco() {
        var end = new Endereco();
        end.setCodigo(2);
        end.setRua("Teste 2");
        end.setCidade("Idade 2");
        end.setEstado("SC");
        end.setCep("4419999");

        var em = _entityManagerFactory.createEntityManager();
        try {
            em.getTransaction().begin();
            try {
                em.merge(end);
                em.getTransaction().commit();
            } catch (Exception e) {
                System.out.println("Transação falhou : ");
                e.printStackTrace();
                em.getTransaction().rollback();
            }
        } finally {
            em.close();
        }
    }

    private EntityManagerFactory createEntityManagerFactory() {
        var factory = Persistence.createEntityManagerFactory("test-hibernate");
        return factory;
    }
}
