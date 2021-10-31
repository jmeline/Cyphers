package caesarCipher;

public class CaesarCipher {
	
		 //Java code
		    public static StringBuffer encrypt(String text, int s){
		        StringBuffer result = new StringBuffer();
//create loop to read each character of test
		        for (int i = 1; i<text.length(); i++){
		        	
		        	//as long as it is uppercase
		            if (Character.isUpperCase(text.charAt(i))){
		            	char ch = (char)(((int)text.charAt(i) + s - 65) % 26 + 65);

		                result.append(ch);
		              }
		              else{
		            	  char ch = (char)(((int)text.charAt(i) + s - 97) % 26 + 97);

		                  result.append(ch);
		              }
		        }
		        return result;
		    }

		    public static void main(String[] args){

		    	
		    	//testing with string ATTACKATONCE
		    	String text = "ATTACKATONCE";

		        int s = 4;

		        System.out.println("Text : " + text);
		        System.out.println("Shift :  " + s);
		        System.out.println("Cipher : " + encrypt(text, s));
		        
		    }
		        

		}


