package org.example;

import java.awt.Color;
import java.awt.Graphics;
import java.util.Random;

public class Food implements Runnable {
    private int x;
    private int y;
    private final int UNIT_SIZE = 25;
    private GamePanel gamePanel;

    public Food(GamePanel gamePanel) {//dostep do panelu gry
        this.gamePanel = gamePanel;
        this.newFood();
    }

    public void newFood() {
        x = new Random().nextInt((int) (gamePanel.getScreenWidth() / UNIT_SIZE)) * UNIT_SIZE;
        y = new Random().nextInt((int) (gamePanel.getScreenHeight() / UNIT_SIZE)) * UNIT_SIZE;
    }

    public void draw(Graphics g) {
        g.setColor(Color.red);
        g.fillRect(x, y, UNIT_SIZE, UNIT_SIZE);
    }

    public int getX() {
        return x;
    }

    public int getY() {
        return y;
    }

    @Override
    public void run() {
        try {
            while (true) {
                Thread.sleep(3000);
                newFood();
            }
        } catch (InterruptedException e) {
            e.printStackTrace();
        }
    }
}

