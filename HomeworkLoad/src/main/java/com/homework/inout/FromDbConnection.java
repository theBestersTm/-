package com.homework.inout;

import java.sql.*;
import java.util.*;

public class FromDbConnection {

    public void StartTest(int testchoice) {
        String url = "jdbc:mysql://localhost/mydb?useUnicode=true&us eJDBCCompliantTimezoneShift=true&useLegacyDatetimeCode=false&serverTimezone=UTC";
        String username = "root";
        String password = "root";

        try {
            Class.forName("com.mysql.cj.jdbc.Driver");
            Connection connection = DriverManager.getConnection(url, username, password);
            Statement statement = connection.createStatement();
        int total_score = 0;
        ResultSet resultSet2 = statement.executeQuery("SELECT id, Test_N, TestName, Question_N, Question, Answer1, Answer2, Answer3, Answer4, Right_answer FROM mydb.test1 WHERE Test_N = " + testchoice+";");


        System.out.println("Lets test begin:");
        while (resultSet2.next()){
            System.out.println("Test "+resultSet2.getString(2)+": " + resultSet2.getString(3));

            if(resultSet2.getInt(2)==1) {
                System.out.print("Question "+resultSet2.getString(4)+":");
                System.out.println(" "+resultSet2.getString(5)+"");
                System.out.println("1. "+resultSet2.getString(6)+"");
                System.out.println("2. "+resultSet2.getString(7)+"");
                System.out.println("3. "+resultSet2.getString(8)+"");
                System.out.println("4. "+resultSet2.getString(9)+"");
                Scanner scanner = new Scanner(System.in);
                int a = scanner.nextInt();
                if(a==resultSet2.getInt(10)){
                    total_score++;
                }


            }

        }
        System.out.println("Your total right score: " + total_score + " Total percent is: "+ (100*total_score)/3+"%");


        resultSet2.close();
        statement.close();
        connection.close();
    } catch (
    SQLException e) {
        e.printStackTrace();
    } catch (ClassNotFoundException e) {
        e.printStackTrace();
    }
    }
    public void SeeAll() {
        String url = "jdbc:mysql://localhost/mydb?useUnicode=true&us eJDBCCompliantTimezoneShift=true&useLegacyDatetimeCode=false&serverTimezone=UTC";
        String username = "root";
        String password = "root";

        try {
            Class.forName("com.mysql.cj.jdbc.Driver");
            Connection connection = DriverManager.getConnection(url, username, password);
            Statement statement = connection.createStatement();
//            ResultSet resultSet = statement.executeQuery("SELECT * FROM employee");
//            while (resultSet.next()) {
//                System.out.println(resultSet.getString(3));
//            }
//            resultSet.close();
           // BasicTestForDB basicTestForDB = new BasicTestForDB();
           // statement.executeUpdate(basicTestForDB.test1);
           // statement.executeUpdate(basicTestForDB.test2);
           // statement.executeUpdate(basicTestForDB.test3);
            SortedSet<Integer> alltestsnumb = new TreeSet<>();
            SortedSet<String> alltestsname = new TreeSet<>();
            ResultSet resultSet2 = statement.executeQuery("SELECT * FROM mydb.test1;");

            while (resultSet2.next()) {

                alltestsnumb.add(resultSet2.getInt(2));
                alltestsname.add(resultSet2.getString(3));
                //System.out.println("Test " + resultSet2.getString(2) + ": " + resultSet2.getString(3));

            }

            resultSet2.close();
            statement.close();
            connection.close();
            Iterator iterator = alltestsnumb.iterator();
            Iterator iterator2 = alltestsname.iterator();

            Scanner scanner = new Scanner(System.in);

            while(iterator.hasNext()){

                System.out.println("Test " + iterator.next().toString() + ": " + iterator2.next().toString());

            }
            System.out.println("Press your test: ");
            int testchoice = scanner.nextInt();
            StartTest(testchoice);

        } catch (
                SQLException e) {
            e.printStackTrace();
        } catch (ClassNotFoundException e) {
            e.printStackTrace();
        }
    }
}
