import models.Endereco;

import javax.persistence.EntityManagerFactory;
import javax.persistence.Persistence;

public class AppEntityManager {
    private EntityManagerFactory _entityManagerFactory;

    public void execute() {
        _entityManagerFactory = createEntityManagerFactory();
        insertEndereco();
    }

    private void insertEndereco() {
        var end = new Endereco();
        end.setCodigo(2);
        end.setRua("Teste 2");
        end.setCidade("Idade 2");
        end.setEstado("SC");
        end.setCep("4419999");

        var manager = _entityManagerFactory.createEntityManager();
        try {
            manager.getTransaction().begin();
            try {
                manager.merge(end);
                manager.getTransaction().commit();
            } catch (Exception e) {
                System.out.println("Transação falhou : ");
                e.printStackTrace();
                manager.getTransaction().rollback();
            }
        } finally {
            manager.close();
        }
    }

    private EntityManagerFactory createEntityManagerFactory() {
        var factory = Persistence.createEntityManagerFactory("test-hibernate");
        return factory;
    }
}
