package org.example;

import javax.swing.JPanel;//do rysowania.
import javax.swing.JOptionPane;//do wyświetlania komunikatów.
import java.awt.*;//do rysowania grafiki i obsługi zdarzeń.
import java.awt.event.ActionEvent;
import java.awt.event.ActionListener;
import java.awt.event.KeyAdapter;
import java.awt.event.KeyEvent;
import javax.swing.Timer;
import java.util.ArrayList;//do przechowywania listy jedzenia i przeszkód.
import java.util.List;
import java.util.concurrent.ExecutorService;//do zarządzania wielowątkowością
import java.util.concurrent.Executors;//do zarządzania wielowątkowością
import java.util.concurrent.TimeUnit;//do zarządzania wielowątkowością
import java.util.Random;//losowanie

public class GamePanel extends JPanel implements Runnable, ActionListener {//Runnable umożliwia uruchamianie kodu w oddzielnym wątku

    private final int SCREEN_WIDTH = 600;
    private final int SCREEN_HEIGHT = 600;
    private final int UNIT_SIZE = 25;
    private final int GAME_UNITS = (SCREEN_WIDTH * SCREEN_HEIGHT) / (UNIT_SIZE * UNIT_SIZE);
    private final int DELAY = 150; // Opóźnienie (w ms) między kolejnymi ruchami węża.
    private final int INITIAL_FOOD_COUNT = 1;
    private final int INITIAL_OBSTACLE_COUNT = 2;
    static final int FOOD_MOVE_INTERVAL = 20;
    private final Color[] colors = {Color.red, Color.blue}; // tablica kolorów jedzenia i przeszkód
    private final int[] x = new int[GAME_UNITS];//Tablica przechowująca pozycje x ciała węża.
    private final int[] y = new int[GAME_UNITS];//Tablica przechowująca pozycje y ciała węża.
    private int bodyParts = 6;
    private int applesEaten;
    private char direction = 'R';//Kierunek, w którym porusza się wąż
    private boolean running = false;//Flaga wskazująca, czy gra jest uruchomiona.
    private Timer timer;
    private List<Food> foods;//Lista jedzenia.
    private List<Obstacle> obstacles;//Lista jedzenia.
    private ExecutorService executorService;//watki
    int foodMoveCounter = 0; // Licznik kroków do zmiany pozycji jedzenia

    public GamePanel() {
        this.setPreferredSize(new Dimension(SCREEN_WIDTH, SCREEN_HEIGHT));
        this.setBackground(Color.black);
        this.setFocusable(true);//pozwala na odbieranie zdarzeń klawiatury.
        this.addKeyListener(new MyKeyAdapter());//nasłuchiwacza klawiatury do panelu.
        this.showGameInfo(); // pokazuje informacje o kolorach przed rozpoczęciem gry
        this.startGame();//Rozpoczyna grę.
    }

    public void showGameInfo() {
        String message = "Kolor jedzenia: czerwony\nKolor przeszkód: niebieski\nWąż porusza się strzałkami.\nKliknij OK aby rozpocząć grę.";
        JOptionPane.showMessageDialog(this, message, "Snake Game", JOptionPane.INFORMATION_MESSAGE);
    }

    public void startGame() {
        foods = new ArrayList<>();
        obstacles = new ArrayList<>();
        executorService = Executors.newFixedThreadPool(3); // Stała liczba wątków: 3
        initializeFoods(); // dodajemy początkowe jedzenie
        initializeObstacles(); // dodajemy początkowe przeszkody
        generateNewSnakePosition(); // ustawiamy nową pozycję węża
        running = true;
        timer = new Timer(DELAY, this);
        timer.start();
        executorService.submit(this);
    }

    public void initializeFoods() {
        for (int i = 0; i < INITIAL_FOOD_COUNT; i++) {
            Food food = new Food(this);
            foods.add(food);
        }
    }

    public void initializeObstacles() {
        for (int i = 0; i < INITIAL_OBSTACLE_COUNT; i++) {
            Obstacle obstacle = new Obstacle(this);
            obstacles.add(obstacle);
        }
    }

    public void generateNewSnakePosition() {
        Random random = new Random();
        boolean validPosition;
        do {//Pętla generująca pozycję głowy węża, aż będzie prawidłowa
            validPosition = true;
            x[0] = random.nextInt((int) (SCREEN_WIDTH / UNIT_SIZE)) * UNIT_SIZE;
            y[0] = random.nextInt((int) (SCREEN_HEIGHT / UNIT_SIZE)) * UNIT_SIZE;
            // Sprawdzamy kolizje z przeszkodami
            for (Obstacle obstacle : obstacles) {//Sprawdza, czy nowa pozycja głowy węża koliduje z przeszkodami.
                if (x[0] == obstacle.getX() && y[0] == obstacle.getY()) {
                    validPosition = false;
                    break;
                }
            }
        } while (!validPosition);

        // Ustawiamy pozostałe części ciała węża za głową
        for (int i = 1; i < bodyParts; i++) {//Ustawia pozycje pozostałych części ciała węża za głową.
            x[i] = x[0] - i * UNIT_SIZE;
            y[i] = y[0];
        }
    }

    @Override
    public void run() {
        while (running) {//pierwszy watek
            try {
                for (Food food : foods) {
                    executorService.submit(food);//drugi watek
                }
                for (Obstacle obstacle : obstacles) {//trzeci watek
                    executorService.submit(obstacle);
                }
                TimeUnit.MILLISECONDS.sleep(DELAY);//usypia na delay
            } catch (InterruptedException e) {//jesli watek na ktorym jest gra zostanie przerwany
                Thread.currentThread().interrupt();
            }
        }
        executorService.shutdown();//zamkniecie watkow
    }

    public void newFood() {
        Food food = new Food(this);
        foods.add(food);
    }

    public void newObstacle() {
        Obstacle obstacle = new Obstacle(this);
        obstacles.add(obstacle);
    }

    public void move() {
        for (int i = bodyParts; i > 0; i--) {
            x[i] = x[i - 1];//przesuwa w miejsce poprzedniej
            y[i] = y[i - 1];
        }

        switch (direction) {//zmiana kierunku
            case 'U':
                y[0] = y[0] - UNIT_SIZE;
                break;
            case 'D':
                y[0] = y[0] + UNIT_SIZE;
                break;
            case 'L':
                x[0] = x[0] - UNIT_SIZE;
                break;
            case 'R':
                x[0] = x[0] + UNIT_SIZE;
                break;
        }
    }

    public void checkApple() {//zjedzone jablko
        for (Food food : foods) {//iteruje po liscie jablek
            if ((x[0] == food.getX()) && (y[0] == food.getY())) {
                bodyParts++;
                applesEaten++;
                foods.remove(food);
                newFood();
                break;
            }
        }
    }

    public void checkCollisions() {
        //czy koliduje z cialem
        for (int i = bodyParts; i > 0; i--) {
            if ((x[0] == x[i]) && (y[0] == y[i])) {
                running = false;
            }
        }
        // lewo
        if (x[0] < 0) {
            running = false;
        }
        // prawo
        if (x[0] > SCREEN_WIDTH) {
            running = false;
        }
        // gora
        if (y[0] < 0) {
            running = false;
        }
        // dol
        if (y[0] > SCREEN_HEIGHT) {
            running = false;
        }
        // czy przeszkoda
        for (Obstacle obstacle : obstacles) { //iteruje po przeszkodach
            if ((x[0] == obstacle.getX()) && (y[0] == obstacle.getY())) {
                running = false;
            }
        }
        if (!running) {
            timer.stop();
            handleGameOver();
        }
    }

    public void handleGameOver() {
        int option = JOptionPane.showConfirmDialog(this, "Przegrałeś! Grasz ponownie?", "Snake Game", JOptionPane.YES_NO_OPTION);
        if (option == JOptionPane.YES_OPTION) {
            resetGame();
        } else {
            System.exit(0);
        }
    }

    public void resetGame() {
        bodyParts = 6;
        applesEaten = 0;
        direction = 'R';
        foods.clear();
        obstacles.clear();
        initializeFoods();
        initializeObstacles();
        generateNewSnakePosition(); // ustawiamy nową pozycję węża
        running = true;
        timer.start();
        repaint();//Odświeża panel gry.
    }

    public void gameOver(Graphics g) {
        // Game Over text
        g.setColor(Color.red);
        g.setFont(new Font("Ink Free", Font.BOLD, 75));
        FontMetrics metrics1 = getFontMetrics(g.getFont());
        g.drawString("Koniec gry", (SCREEN_WIDTH - metrics1.stringWidth("Koniec gry")) / 2, SCREEN_HEIGHT / 2);
        // Score
        g.setColor(Color.white);
        g.setFont(new Font("Ink Free", Font.BOLD, 40));
        FontMetrics metrics2 = getFontMetrics(g.getFont());
        g.drawString("Score: " + applesEaten, (SCREEN_WIDTH - metrics2.stringWidth("Score: " + applesEaten)) / 2, g.getFont().getSize());
    }

    @Override
    public void paintComponent(Graphics g) {
        super.paintComponent(g);
        draw(g);
    }

    public void draw(Graphics g) {
        if (running) {
            for (int i = 0; i < SCREEN_HEIGHT / UNIT_SIZE; i++) {
                g.drawLine(i * UNIT_SIZE, 0, i * UNIT_SIZE, SCREEN_HEIGHT);
                g.drawLine(0, i * UNIT_SIZE, SCREEN_WIDTH, i * UNIT_SIZE);
            }
            for (Food food : foods) {
                food.draw(g);
            }
            for (Obstacle obstacle : obstacles) {
                obstacle.draw(g);
            }
            for (int i = 0; i < bodyParts; i++) {
                if (i == 0) {
                    g.setColor(Color.green);
                    g.fillRect(x[i], y[i], UNIT_SIZE, UNIT_SIZE);
                } else {
                    g.setColor(new Color(45, 180, 0));
                    g.fillRect(x[i], y[i], UNIT_SIZE, UNIT_SIZE);
                }
            }
            g.setColor(Color.red);
            g.setFont(new Font("Ink Free", Font.BOLD, 40));
            FontMetrics metrics = getFontMetrics(g.getFont());
            g.drawString("Score: " + applesEaten, (SCREEN_WIDTH - metrics.stringWidth("Score: " + applesEaten)) / 2, g.getFont().getSize());
        } else {
            gameOver(g);
        }
    }

    @Override
    public void actionPerformed(ActionEvent e) {// tykanie timera powoduje aktualizowanie gry
        if (running) {
            move();
            checkApple();
            checkCollisions();
        }
        repaint();
    }

    public int getScreenWidth() {
        return SCREEN_WIDTH;
    }

    public int getScreenHeight() {
        return SCREEN_HEIGHT;
    }

    public class MyKeyAdapter extends KeyAdapter {
        @Override
        public void keyPressed(KeyEvent e) {
            switch (e.getKeyCode()) {
                case KeyEvent.VK_LEFT:
                    if (direction != 'R') {
                        direction = 'L';
                    }
                    break;
                case KeyEvent.VK_RIGHT:
                    if (direction != 'L') {
                        direction = 'R';
                    }
                    break;
                case KeyEvent.VK_UP:
                    if (direction != 'D') {
                        direction = 'U';
                    }
                    break;
                case KeyEvent.VK_DOWN:
                    if (direction != 'U') {
                        direction = 'D';
                    }
                    break;
            }
        }
    }
}
