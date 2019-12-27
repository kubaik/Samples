import models.Endereco;
import org.hibernate.SessionFactory;
import org.hibernate.cfg.Configuration;

public class AppSessionFactory {
    private SessionFactory _sessionFactory;

    public void execute() {
        _sessionFactory = createHibernateFactoryWithoutPersistenceXml();
        insertEndereco();
    }

    private void insertEndereco() {
        var end = new Endereco();
        end.setCodigo(1);
        end.setRua("Av. Getúlio Vargas");
        end.setCidade("Feira de Santana");
        end.setEstado("BA");
        end.setCep("4419999");

        try (var session = _sessionFactory.openSession()) {
            var tx = session.beginTransaction();
            try {
                session.saveOrUpdate(end);
                tx.commit();
            } catch (Exception e) {
                System.out.println("Transação falhou : ");
                e.printStackTrace();
                tx.rollback();
            }
        }
    }

    private SessionFactory createHibernateFactoryWithoutPersistenceXml() {
        var config = new Configuration().
                setProperty("hibernate.dialect", "org.hibernate.dialect.PostgreSQLDialect").
                setProperty("hibernate.connection.driver_class", "org.postgresql.Driver").
                setProperty("hibernate.connection.url", String.format("jdbc:postgresql://%s:%s/%s", Main.HOST, Main.PORT, Main.DATABASE_NAME)).
                setProperty("hibernate.connection.username", Main.USER).
                setProperty("hibernate.connection.password", Main.PASSWORD).
                setProperty("hibernate.show_sql", "true");

        config.addClass(Endereco.class);
        return config.buildSessionFactory();
    }
}
