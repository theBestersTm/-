package com.homework.inout;
import java.io.FileWriter;
import java.io.IOException;
import java.io.Writer;
import java.nio.charset.Charset;
import java.nio.file.Files;
import java.nio.file.Paths;
import java.sql.SQLOutput;
import java.util.List;
import java.util.Scanner;
import java.sql.*;
import java.util.*;
import java.util.Scanner;

public class DBSaveTest {

    public void CreateNewTest(int testchoice){
        String url = "jdbc:mysql://localhost/mydb?useUnicode=true&us eJDBCCompliantTimezoneShift=true&useLegacyDatetimeCode=false&serverTimezone=UTC";
        String username = "root";
        String password = "root";

        try {
            Class.forName("com.mysql.cj.jdbc.Driver");
            Connection connection = DriverManager.getConnection(url, username, password);
            Statement statement = connection.createStatement();
            int total_score = 0;
          //  ResultSet resultSet2 = statement.executeQuery("SELECT id, Test№, TestName, Question_№, Question, Answer1, Answer2, Answer3, Answer4, Right_answer FROM mydb.test WHERE Test№ = " + testchoice+";");
            int test_n=0;
            String test_name;
            String question;
            String answer1;
            String answer2;
            String answer3;
            String answer4;
            int right_answer=0;



                Scanner scanner = new Scanner(System.in);
                System.out.println("Input test number:");
                test_n = scanner.nextInt();
                System.out.println("Input test name:");
                test_name = scanner.nextLine();
                System.out.println("Input question amount:");

                int question_amount = scanner.nextInt();

                for (int a = 0; a < question_amount; a++) {
                    scanner.nextLine();
                    System.out.println("Input your question " + (a + 1) + ":");
                    question = scanner.nextLine();


                    for (int i = 0; i < 4; i++) {
                        System.out.println("Input your answer " + (i + 1));
                        String answer = scanner.nextLine();

                        String test3 = "INSERT INTO mydb.test1 (Test_N, TestName, Question_N, Question, Answer1)" +
                                "VALUES (" + test_n + ", '" + test_name + "'," + (a + 1) + ", '" + question + "', '"+answer+"');";
                        statement.executeUpdate(test3);
                    }

                }

                    System.out.println("Input your right number answer "+":");
                    right_answer = scanner.nextInt();
                    String test3 = "INSERT INTO mydb.test1 (Right_answer)" +
                    "VALUES ("+right_answer+") WHERE test1.Test_N = "+test_n+";";
            statement.executeUpdate(test3);

//            while (resultSet2.next()){
//                System.out.println("Test "+resultSet2.getString(2)+": " + resultSet2.getString(3));
//
//
//
//            }



           // resultSet.close();
            statement.close();
            connection.close();

        } catch (
                SQLException e) {
            e.printStackTrace();
        } catch (ClassNotFoundException e) {
            e.printStackTrace();
        }
    }
    }

