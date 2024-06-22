package org.example;

import java.util.Scanner;

public class Main {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);

        System.out.println("Podaj ilosc przedmiotow:");
        int n = scanner.nextInt();

        System.out.println("Podaj ziarno:");
        int seed = scanner.nextInt();

        System.out.println("Podaj pojemnosc plecaka:");
        int capacity = scanner.nextInt();

        Problem problem = new Problem(n, seed, 1, 10);
        System.out.println("Wygenerowane przedmioty:");
        System.out.println(problem.toString());

        Result result = problem.solve(capacity);
        System.out.println("Rozwiązanie dla pojemności plecaka: " + capacity);
        System.out.println(result.toString());
    }
}
