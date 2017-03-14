package org.yy.core.risk.task;

import java.util.Objects;

/**
 * Created by chinanet on 2017/3/14.
 */
public class Tuple3<T1, T2, T3> extends Tuple<T1, T2> {
    private final T3 third;

    public Tuple3(T1 first, T2 second, T3 t3) {
        super(first, second);
        this.third = t3;
    }

    public T3 getThird() {
        return third;
    }

    @Override
    public boolean equals(Object o) {
        if (this == o) return true;
        if (!(o instanceof Tuple3)) return false;
        if (!super.equals(o)) return false;
        Tuple3<?, ?, ?> tuple3 = (Tuple3<?, ?, ?>) o;
        return Objects.equals(third, tuple3.third);
    }

    @Override
    public int hashCode() {
        return Objects.hash(this.getFirst(), this.getSecond(), third);
    }

    @Override
    public String toString() {
        return "Tuple3{" +
                "first=" + getFirst() +
                ", second=" + getSecond() +
                ", third=" + third +
                '}';

    }
}
