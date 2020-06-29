package com.sdzee.checkFile;

import java.util.ArrayList;

import com.sdzee.bdd.Oracle;

public class CheckFile {
	
	public CheckFile() {
		
	}
	
	public void analysFile(String file) {
		
		int totalWords;
		int occurenceNumber = 0;
		
		System.out.println("CHECKING DB...");
		
		Oracle testOracle = new Oracle();
		
		ArrayList<String> dictionary = testOracle.retrieveDictionary();
		
		String[] words = file.split("\\s+");
		
		totalWords = words.length;
		
		for(int i = 0; i < words.length; i++) {
			
			//System.out.println(words[i]);
			
		      for (String element : dictionary){
		          if (element.equals(words[i])){
		                System.out.println(element);
		                System.out.println("FOUND" + words[i]);
		                occurenceNumber++;
		          }
		       }
			//System.out.println(dictionary.get(i));
		}
		
		System.out.println("TOTAL WORDS : " + totalWords + "OCCURENCE FOUNDED : " + occurenceNumber);
		
		
		
	}

}
