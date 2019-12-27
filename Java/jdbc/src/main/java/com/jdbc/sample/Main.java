package com.jdbc.sample;

import java.sql.Connection;
import java.sql.DriverManager;
import java.sql.ResultSet;
import java.sql.SQLException;
import java.sql.Statement;
import java.util.logging.Level;
import java.util.logging.Logger;

public class Main {
    public static void main(String[] args) {
        var url = "jdbc:postgresql://localhost:5432/teste";
        var user = "postgres";
        var password = "123456*";

        try (var con = DriverManager.getConnection(url, user, password);
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
