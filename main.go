package main

import (
	"bufio"
	"fmt"
	"os"
	"strings"
	"unicode"
)

var tskeyword = map[string]string{
	"int":      "number",
	"long":     "number",
	"short":    "number",
	"double":   "number",
	"decimal":  "number",
	"bool":     "boolean",
	"string":   "string",
	"DateTime": "Date",
	"int?":     "number",
	"long?":    "number",
	"short?":   "number",
	"double?":  "number",
	"decimal?": "number",
	"bool?":    "boolean",
}

func check(e error) {
	if e != nil {
		panic(e)
	}
}

func main() {

	f, _ := os.Open("csharps/UnitDto.cs")
	fscanner := bufio.NewScanner(f)
	for fscanner.Scan() {
		l := fscanner.Text()
		hasPublic := strings.Contains(l, "public")
		if hasPublic == true {
			if strings.Contains(l, "class") != true {
				keys := strings.Fields(l)
				systemType := strings.ToLower(keys[1])
				mappingType := tskeyword[systemType]
				fmt.Println(LcFirst((keys[2]))+":", mappingType+";")
			}
		}
	}
}

func LcFirst(str string) string {
	for i, v := range str {
		return string(unicode.ToLower(v)) + str[i+1:]
	}
	return ""
}
