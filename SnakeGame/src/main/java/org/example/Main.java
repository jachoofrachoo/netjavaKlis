package org.example;

import javax.swing.JFrame; //służy do tworzenia głównego okna aplikacji.

public class Main extends JFrame { //dziedziczy po JFrame, co oznacza, że Main jest oknem aplikacji.

    public Main() {
        this.add(new GamePanel()); //Dodaje do okna głównego (JFrame) panel gry (GamePanel)
        this.setTitle("Snake Game"); //Ustawia tytuł okna.
        this.setDefaultCloseOperation(JFrame.EXIT_ON_CLOSE); //Ustawia, aby aplikacja zamykała się po kliknięciu "X" w oknie.
        this.setResizable(false); //Ustawia, że okno nie może być zmieniane (rozszerzane/zawężane).
        this.pack(); //Ustawia rozmiar okna na podstawie jego zawartości.
        this.setLocationRelativeTo(null); //Ustawia okno na środku ekranu.
        this.setVisible(true); //Ustawia okno jako widoczne.
    }

    public static void main(String[] args) {
        new Main(); //Metoda główna, punkt wejścia do programu. Tworzy nową instancję klasy Main
    }
}
