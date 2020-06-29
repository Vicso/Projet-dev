package com.sdzee.checkFile;

import java.util.ArrayList;

import com.sdzee.bdd.Oracle;

public class CheckFile {
	
	ArrayList<String> dictionary;
	int currentIndex = 0;
	int resetIndex = 0;
	
	public CheckFile() {
		
	}
	
	public void loadDictionary() {
		
		System.out.println("CHECKING DB...");
		
		Oracle testOracle = new Oracle();
		
		dictionary = testOracle.retrieveDictionary();
	}
	
	public void analysFile(String file) {
		
		int totalWords;
		int occurenceNumber = 0;
		
		String[] words = file.split("\\s+");
		
		totalWords = words.length;
		
		for(int i = 0; i < words.length; i++) {
			
			//System.out.println(words[i]);
			
		      for (String element : dictionary){
		          if (element.equals(words[i])){
		                //System.out.println(element);
		                //System.out.println("FOUND" + words[i]);
		                occurenceNumber++;
		          }
		       }
			//System.out.println(dictionary.get(i));
		}
		
		if(occurenceNumber > 0) {
			if(totalWords / occurenceNumber >= 1.5) {
				System.out.println("good");
			}else {
				System.out.println("not bad not terrible" + totalWords + occurenceNumber);
			}
		}
		
		if(resetIndex > 100) {
			System.out.println("done checking " + currentIndex);
			resetIndex = 0;
		}
		
		currentIndex++;
		resetIndex++;

		
		//System.out.println("TOTAL WORDS : " + totalWords + "OCCURENCE FOUNDED : " + occurenceNumber);
		
		
		
	}

}
