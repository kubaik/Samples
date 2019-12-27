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

    public static void main(String[] args) {
        System.out.println("Hibernate Demo");
        printPostgreSqlVersion();

//        new AppSessionFactory().execute();
        new AppEntityManager().execute();

        System.out.println("end of Hibernate Demo");
    }

    public static void printPostgreSqlVersion() {
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
