package org.example;

import static org.junit.jupiter.api.Assertions.*;
import org.junit.jupiter.api.Test;

import java.util.ArrayList;
import java.util.List;

public class ProblemTest {

    @Test
    public void testCoNajmniejJedenPasuje() {
        Problem problem = new Problem(5, 123, 1, 10);
        int capacity = 20;
        Result result = problem.solve(capacity);
        assertTrue(result.totalWeight > 0);
    }

    @Test
    public void testNIcNIePasuje() {
        Problem problem = new Problem(5, 1, 11, 20);
        int capacity = 0;
        Result result = problem.solve(capacity);
        assertEquals(0, result.totalWeight);
        assertEquals(0, result.totalValue);
    }

    @Test
    public void testSprawdzanieWagiWartosci() {
        Problem problem = new Problem(5, 123, 1, 10);
        List<Item> items = problem.getItems();
        for (Item item : items) {
            assertTrue(item.weight >= 1 && item.weight <= 10);
            assertTrue(item.value >= 1 && item.value <= 10);
        }
    }

    @Test
    public void testDlaInstancji() {
        List<Item> items = new ArrayList<>();
        items.add(new Item(5, 2));
        items.add(new Item(10, 3));
        items.add(new Item(8, 1));
        items.add(new Item(3, 5));
        Problem problem = new Problem(items);
        int capacity = 6;
        Result result = problem.solve(capacity);
        assertEquals(6, result.totalWeight);
        assertEquals(48, result.totalValue);
        assertEquals(List.of(6, 0, 0, 0), result.itemCounts);
    }
}