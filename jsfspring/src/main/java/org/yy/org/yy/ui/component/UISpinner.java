package org.yy.org.yy.ui.component;

import javax.faces.component.FacesComponent;
import javax.faces.component.UIInput;
import javax.faces.context.FacesContext;
import javax.faces.context.ResponseWriter;
import javax.faces.convert.IntegerConverter;
import java.io.IOException;
import java.util.Map;

/**
 * Created by yyi on 14-6-6.
 */
@FacesComponent("org.yy.jsf.Spinner")
public class UISpinner extends UIInput {
    private static final String MORE = ".more";
    private static final String LESS = ".less";

    public UISpinner() {
        setConverter(new IntegerConverter());
        setRendererType(null);
    }

    @Override
    public void decode(FacesContext context) {
        Map<String, String> requestMap = context.getExternalContext().getRequestParameterMap();
        String clientId = getClientId(context);
        int increment;
        if (requestMap.containsKey(clientId + MORE)) {
            increment = 1;
        } else if (requestMap.containsKey(clientId + LESS)) {
            increment = -1;
        } else {
            increment = 0;
        }
        try {
            int submittedValue = Integer.parseInt(requestMap.get(clientId));
            int newValue = getIncrementedValue(submittedValue, increment);
            setSubmittedValue("" + newValue);
        } catch (NumberFormatException ex) {
            setSubmittedValue(requestMap.get(clientId));
        }
    }

    private int getIncrementedValue(int submittedValue, int increment) {
        Integer min = toInteger(getAttributes().get("minimum"));
        Integer max = toInteger(getAttributes().get("maxinum"));
        int newValue = submittedValue + increment;
        if ((min == null || newValue >= min.intValue()) && (max == null || newValue <= max.intValue())) {
            return newValue;
        } else {
            return submittedValue;
        }
    }

    private Integer toInteger(Object value) {
        if (value == null) {
            return null;
        }
        if (value instanceof Number) {
            return ((Number) value).intValue();
        }
        if (value instanceof String) {
            return Integer.parseInt((String) value);
        }
        throw new IllegalArgumentException("Cannot convert " + value);
    }

    @Override
    public void encodeBegin(FacesContext context) throws IOException {
        ResponseWriter writer = context.getResponseWriter();
        String clientId = getClientId(context);
        encodeInputField(writer, clientId);
        encodeDecrementButton(writer, clientId);
        encodeIncrementButton(writer, clientId);
    }

    private void encodeIncrementButton(ResponseWriter writer, String clientId) throws IOException {
        writer.startElement("input", this);
        writer.writeAttribute("type", "submit", null);
        writer.writeAttribute("name", clientId + MORE, null);
        writer.writeAttribute("value", ">", "value");
        writer.endElement("input");
    }

    private void encodeDecrementButton(ResponseWriter writer, String clientId) throws IOException {
        writer.startElement("input", this);
        writer.writeAttribute("type", "submit", null);
        writer.writeAttribute("name", clientId + LESS, null);
        writer.writeAttribute("value", "<", "value");
        writer.endElement("input");
    }

    private void encodeInputField(ResponseWriter writer, String clientId) throws IOException {
        writer.startElement("input", this);
        writer.writeAttribute("name", clientId, null);
        Object v = getValue();
        if (v != null) {
            writer.writeAttribute("value", v, "value");
        }
        Object size = getAttributes().get("size");
        if (size != null) {
            writer.writeAttribute("size", size, "size");
        }
        writer.endElement("input");
    }
}
