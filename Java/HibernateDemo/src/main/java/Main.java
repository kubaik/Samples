import models.Endereco;
import org.hibernate.SessionFactory;
import org.hibernate.cfg.Configuration;

import javax.persistence.EntityManager;
import javax.persistence.EntityManagerFactory;
import javax.persistence.Persistence;
import java.sql.DriverManager;
import java.sql.SQLException;
import java.util.logging.Level;
import java.util.logging.Logger;

public class Main {
    public static final String HOST = "localhost";
    public static final int PORT = 5432;
    public static final String USER = "postgres";
    public static final String PASSWORD = "123456";
    public static final String DATABASE_NAME = "test-java-hibernate";

    private SessionFactory _sessionFactory;
    private EntityManagerFactory _entityManagerFactory;

    public static void main(String[] args) {
        System.out.println("Hibernate Demo");
        var app = new Main();
        app.printPostgreSqlVersion();
        app.hibernateDemo();

        System.out.println("end of Hibernate Demo");
    }

    private void hibernateDemo() {
//        _sessionFactory = createHibernateFactoryWithoutPersistenceXml();
//        insertEnderecoWithSessonFactory();

        _entityManagerFactory = createEntityManagerFactory();
        insertEnderecoWithEntityManager();
    }

    private void insertEnderecoWithSessonFactory() {
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

    private void insertEnderecoWithEntityManager() {
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

    private SessionFactory createHibernateFactoryWithoutPersistenceXml() {
        var config = new Configuration().
                setProperty("hibernate.dialect", "org.hibernate.dialect.PostgreSQLDialect").
                setProperty("hibernate.connection.driver_class", "org.postgresql.Driver").
                setProperty("hibernate.connection.url", String.format("jdbc:postgresql://%s:%s/%s", HOST, PORT, DATABASE_NAME)).
                setProperty("hibernate.connection.username", USER).
                setProperty("hibernate.connection.password", PASSWORD).
                setProperty("hibernate.show_sql", "true");

        config.addClass(Endereco.class);
        return config.buildSessionFactory();
    }

    private EntityManagerFactory createEntityManagerFactory() {
        var factory = Persistence.createEntityManagerFactory("test-hibernate");
        return factory;
    }

    public void printPostgreSqlVersion() {
        var url = String.format("jdbc:postgresql://%s:%s/%s", HOST, PORT, DATABASE_NAME);

        try (var con = DriverManager.getConnection(url, USER, PASSWORD);
             var st = con.createStatement();
             var rs = st.executeQuery("select version()")) {

            if (rs.next()) {
                System.out.println(rs.getString(1));
            }
        } catch (SQLException ex) {
            Logger lgr = Logger.getLogger(Main.class.getName());
            lgr.log(Level.SEVERE, ex.getMessage(), ex);
        }
    }
}
