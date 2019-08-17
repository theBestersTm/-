package com.homework.inout;
import com.homework.inout.BasicTest;
import com.homework.inout.Loadout;
import com.homework.inout.SaveIn;

import java.io.IOException;
import java.util.ArrayList;
import java.util.List;
import java.util.Scanner;
import com.homework.inout.Loadout;

import java.util.Scanner;

public class Menu {

    public void startmenu() {

        Loadout loadout = new Loadout();

        Scanner scanner = new Scanner(System.in);
        System.out.println("Hi this is my test program, now you can use quick menu to use it");
        System.out.println("Print 0 if you want to see all tests and info");
        System.out.println("Print 1 if you want to choose test already");
        System.out.println("Print 2 if you want to create it in your own");
        System.out.println("Print 3 if you want to see db data");
        System.out.println("Print 4 if you want exit");
        int a = scanner.nextInt();
        switch (a) {
            case 0:
                loadout.SearchNameInfo();
                System.out.println("Choose your test");
                int b = scanner.nextInt();
                loadout.ChooseTest(b);
                break;
            case 1:
                loadout.ChooseTest(a);
                break;
            case 2:
                SaveIn saveIn = new SaveIn();
                saveIn.Save(loadout.TotalAmountTest());

                break;
            case 3:
                FromDbConnection fromDbConnection = new FromDbConnection();
                fromDbConnection.SeeAll();
                break;
            case 4:
                System.exit(0);

            default:
                throw new IllegalStateException("Unexpected value: " + a);
        }


    }
}
