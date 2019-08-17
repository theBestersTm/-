package com.homework.inout;
import java.io.IOException;
import java.nio.charset.Charset;
import java.nio.file.Files;
import java.nio.file.Paths;
import java.sql.SQLOutput;
import java.util.List;
import java.util.Scanner;

public class Loadout {
    static List<String> lines;
    static int count=0;
    boolean end = false;
    static {
        try {
            lines = Files.readAllLines(Paths.get("file.txt"), Charset.defaultCharset());
        } catch (IOException e) {
            e.printStackTrace();
        }
    }

    public void CheckFile(){
        if(lines.isEmpty()){
        BasicTest basicTest = new BasicTest();
        SaveIn saveIn = new SaveIn();
        saveIn.SaveBasic(basicTest.TestInfo());
    }
    }
    public int TotalAmountTest(){
        SearchInfo("Test: " , false);
        return count;
    }

     public void SearchNameInfo(){
        SearchInfo("Name: ", true);
     }

     public void ChooseTest( int Test){
         CheckFile();
        int total_score = 0;
        for (int i = 0; i <= lines.size() - 1; i++){

            Scanner scanner = new Scanner(System.in);

            String row = lines.get(i);
            if(row.equals("Test " + Test)){
                System.out.println("");
                System.out.println("Lets test begin:");
                for (int a = i; a <= lines.size()-1; a++){
                    if(!lines.get(a).contains("Right answer: ")){
                        System.out.println(lines.get(a));

                    }
                    if(lines.get(a).contains("Right answer: ")){
                        System.out.println("Write your answer: ");
                        String m = scanner.nextLine();

                        if(lines.get(a).equals("Right answer: "+m)){
                            total_score++;
                        };
                    }
                    if(lines.get(a).contains("end")){
                        end = true;
                        break;
                    }
                }
                System.out.println("Your total right score: " + total_score + " Total percent is: "+ (100*total_score)/3+"%");
                break;
            }
            else if(end==true){
                break;
            }
        }

    }

    public void SearchInfo(String info, Boolean print){
        CheckFile();
        for (String x:lines)
        {
            if (x.contains(info)||x.contains("Test ")&& print == true){
                System.out.println(x);
            }
            else if(x.contains("Test ")&& print == false){
                count++;
            }
        }
    }
}
