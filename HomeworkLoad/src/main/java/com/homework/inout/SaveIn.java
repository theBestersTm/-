package com.homework.inout;

import java.io.FileWriter;
import java.io.IOException;
import java.io.PrintWriter;
import java.io.Writer;
import java.util.ArrayList;
import java.util.List;
import java.util.Scanner;

public class SaveIn {
    public void SaveBasic (List<String> str) {


        Writer writer = null;
        try {
            writer = new FileWriter("file.txt");
            for (String line : str) {
                writer.append(line);

                writer.append(System.getProperty("line.separator"));
            }
            writer.flush();
        } catch (IOException ex) {
            System.err.println(ex);
        } finally {
            if (writer != null) {
                try {
                    writer.close();
                } catch (IOException ex) {
                }
            }
        }
    }

    public void  Save(int count){
        Writer writer = null;
        try {
            writer = new FileWriter("file.txt", true);

            Scanner scanner = new Scanner(System.in);
            System.out.println("Input test name:");
            String textinfo = scanner.nextLine();
            System.out.println("Input question amount:");


            int question_amount = scanner.nextInt();
                writer.append("===============================");
                writer.append(System.getProperty("line.separator"));
                writer.append("Test " + (count+1));
                writer.append(System.getProperty("line.separator"));
                writer.append("Name: " + textinfo );
                writer.append(System.getProperty("line.separator"));


            for (int a = 0; a < question_amount; a++) {
                scanner.nextLine();
                System.out.println("Input your question " + (a+1) +":");
                    String textinfo3 = scanner.nextLine();
                    writer.append("Question "+(a+1)+":"+textinfo3);
                    writer.append(System.getProperty("line.separator"));

                    for (int i = 0; i<4; i++){
                        System.out.println("Input your answer "+(i+1));
                        String anwser = scanner.nextLine();

                        writer.append(i+". " + anwser);
                        writer.append(System.getProperty("line.separator"));
                    }
                    System.out.println("Input your right number answer "+":");
                    String textinfo1 = scanner.next();
                    writer.append("Right answer: " + textinfo1);
                    writer.append(System.getProperty("line.separator"));


                writer.append(System.getProperty("line.separator"));
            }

            writer.append("end");
            writer.append(System.getProperty("line.separator"));

            writer.flush();
        } catch (IOException ex) {
            System.err.println(ex);
        } finally {
            if (writer != null) {
                try {
                    writer.close();
                } catch (IOException ex) {
                }
            }
        }
    }
}
