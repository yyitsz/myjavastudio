package tools.sqltool;

import java.lang.reflect.Method;
import java.lang.reflect.Type;
import org.junit.Test;

/**
 * Unit test for simple App.
 */
public class AppTest {

    @Test
    public void testApp() throws NoSuchMethodException {
        Class<AppTest> clazz = AppTest.class;
        Method method = clazz.getMethod("setId", Long.class);
        Type type = method.getGenericParameterTypes()[0];
        System.out.println(type);

        method = clazz.getMethod("setId", long.class);
        type = method.getGenericParameterTypes()[0];
        System.out.println(type);

    }

    public void setId(Long id) {
    }

    public void setId(long id) {
    }
}
