package org.example;

import java.util.ArrayList;
import java.util.List;
import java.util.Random;

import java.util.ArrayList;
import java.util.List;
import java.util.Random;

public class Problem {
    private int n;
    private int seed;
    private int lowerBound;
    private int upperBound;
    private List<Item> items;

    public Problem(int n, int seed, int lowerBound, int upperBound) {
        this.n = n;
        this.seed = seed;
        this.lowerBound = lowerBound;
        this.upperBound = upperBound;
        this.items = new ArrayList<>();
        generateItems();
    }

    public Problem(List<Item> items) {
        this.items = items;
        this.n = items.size();
    }


    private void generateItems() {
        Random random = new Random(seed);
        for (int i = 0; i < n; i++) {
            int value = lowerBound + random.nextInt(upperBound - lowerBound + 1);
            int weight = lowerBound + random.nextInt(upperBound - lowerBound + 1);
            items.add(new Item(value, weight));
        }
    }

    public Result solve(int capacity) {
        items.sort((a, b) -> Double.compare((double) b.value / b.weight, (double) a.value / a.weight));

        int remainingCapacity = capacity;
        int totalValue = 0;
        int totalWeight = 0;
        List<Integer> itemCounts = new ArrayList<>();

        for (int i = 0; i < items.size(); i++) {
            itemCounts.add(0);
        }

        for (int i = 0; i < items.size(); i++) {
            Item item = items.get(i);
            while (remainingCapacity >= item.weight) {
                remainingCapacity -= item.weight;
                totalValue += item.value;
                totalWeight += item.weight;
                itemCounts.set(i, itemCounts.get(i) + 1);
            }
        }

        return new Result(itemCounts, totalValue, totalWeight);
    }

    public List<Item> getItems() {
        return items;
    }

    @Override
    public String toString() {
        StringBuilder sb = new StringBuilder();
        for (Item item : items) {
            sb.append(item.toString()).append("\n");
        }
        return sb.toString();
    }
}


// Klasa reprezentująca przedmiot
class Item {
    int value;
    int weight;

    Item(int value, int weight) {
        this.value = value;
        this.weight = weight;
    }

    @Override
    public String toString() {
        return "Item{" +
                "value=" + value +
                ", weight=" + weight +
                '}';
    }
}

// Klasa reprezentująca wynik rozwiązania problemu
class Result {
    List<Integer> itemCounts;
    int totalValue;
    int totalWeight;

    Result(List<Integer> itemCounts, int totalValue, int totalWeight) {
        this.itemCounts = itemCounts;
        this.totalValue = totalValue;
        this.totalWeight = totalWeight;
    }

    @Override
    public String toString() {
        return "Result{" +
                "itemCounts=" + itemCounts +
                ", totalValue=" + totalValue +
                ", totalWeight=" + totalWeight +
                '}';
    }
}
