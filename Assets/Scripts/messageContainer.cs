﻿using UnityEngine;
using System.Collections;

//for using Dictionaries.
using System.Collections.Generic;	

//This class contains several game messages.
public class messageContainer : MonoBehaviour {


	public enum statusType //enum that tracks what is in the current Square, plus an out_of_map value.
	{
		//Some messages are not stored, but generated, such as:
		//Notifying the current turn.
		
		//Introduction.
		GAME_START=0,
		
		
		//Ending Messages
		SURVIVAL_ENDING,
		DRY_ENDING,
		DISTRESS_ENDING,
		LENDER_ENDING,
		
		DISPATCH_SURVIVAL_ENDING,
		DISPATCH_DRY_ENDING,
		DISPATCH_DISTRESS_ENDING,
				
		//Incident Messages
		INCIDENT_LEAK,
		INCIDENT_WATER_SCARCITY,
		
		REPAIRED_LEAK,
		REMEDY_WATER_SCARCITY,
		
		
		//Low parameters warning.
		WARNING_LOW_WATER_LEVEL,
		WARNING_LENDER_DEADLINE,
		
		//Message types.
		NEWS_BRIEF,
		DISPATCH_MESSAGE,
		
		STATE_POSITIVE,
		STATE_AVERAGE,
		STATE_TOUGH,
		
		
		//Population state (related to Distress).
			//in low (or manageable) distress levels.
			POP_STATE_POSITIVE_1,
			POP_STATE_POSITIVE_2,
			POP_STATE_POSITIVE_3,	
			POP_STATE_POSITIVE_4,		

			//in more stressful conditions. (middle)
			POP_STATE_AVERAGE_1,
			POP_STATE_AVERAGE_2,
			POP_STATE_AVERAGE_3,	
			POP_STATE_AVERAGE_4,
				
			//in very stressful conditions. (difficult)
			POP_STATE_TOUGH_1,
			POP_STATE_TOUGH_2,
			POP_STATE_TOUGH_3,	
			POP_STATE_TOUGH_4,	
											
	};
	
	//Defining Dictionary array.
	public static Dictionary<statusType, string> gameStateMessages;
	public  Dictionary<statusType, string[]> dispatchMessages;
	public  Dictionary<statusType, string[]> newsBriefs;
	
//	public static string getDispatchMessage(int turn, statusType inputStatus)
//	{
//	
//		string result="";
//
//
//		return result;		
//			
//	}
	
	public  string getNewsBrief(int turn) //, statusType inputStatus)
	{
		
		string result="";
		
		if (turn < 4)
			{result=newsBriefs[statusType.STATE_POSITIVE][turn];
			}
		else if (turn == 4)
			result= newsBriefs[statusType.STATE_AVERAGE][0];
		else if (turn == 5)
			result= newsBriefs[statusType.STATE_AVERAGE][1];
		else if (turn == 6)
			result= newsBriefs[statusType.STATE_TOUGH][0];
		else if (turn == 7)
			result= newsBriefs[statusType.STATE_TOUGH][1];
		
		return result;
		
	}
	
	
//for using Dictionaries.
	// Use this for initialization
	void Awake () 
	{
		
		gameStateMessages = new Dictionary<statusType, string>();
		newsBriefs= new  Dictionary<statusType, string[]> ();
		
	
		setupDictionary();
	
	}
	
	void setupDictionary()
	{
	
		//Ending messages.
		//Initializing message strings.
		//setting up statusMsg array.
		
		
	//---------1.Game State Messages Intro and Endings.----------
		
			//Introduction String.
			gameStateMessages.Add(statusType.GAME_START, 
		                   	   "It is May 2015.\n"+
		                   	   "Puerto Rico is in its worst <b>drought</b> in 20 years."+ 
		                   	   " Water rationing has officialy begun.\n\n"+   
		                   	   
		                   		"You are the President of the Aqueduct and Sewer Authority.\n"+
		                   		"With limited personnel and resources,\n" +
		                   		"you must manage the crisis for the next 16 weeks.\n\n"+
		                   	   
			                   "<i>(1)Protect your bondholders' interests,\n"+
			                   "(2)Keep water levels above critical,\n"+
			                   "and (3)Supply enough water to the population</i>.\n\n"	   
		                   	   );
							
				
			//Ending messages.		
			gameStateMessages.Add(statusType.SURVIVAL_ENDING, 
			                   "You have survived the drought period.\n"+
		                 	   "Water levels remained above critical,\n"+
			                   "and the population has sufficient water.\n"+
		                   	   //"and the bondholders are satisfied with your performance.\n\n"+
		                   	   "Heavy rain showers are expected to fall over the coming weeks."
			                   //"but the next water crisis may be just around the corner.\n\nStay vigilant. "           
			                  );
			
			gameStateMessages.Add(statusType.DRY_ENDING, 
			                   "You have failed.\n"+
			                   "Many water reservoirs are depleted beyond recovery levels.\n"+         
		                   	   "How will the people find water now?"                
			                  );
			
			gameStateMessages.Add(statusType.DISTRESS_ENDING, 
		                   	   "You have failed.\n"+
		                   	   "Insufficient water services have led to a sanitation crisis.\n"+
			                   "Outbreaks of the West Nile Virus and worm diseases are being reported."
			                  );
			
			gameStateMessages.Add(statusType.LENDER_ENDING, 
		                   	   "You have failed.\n"+
		                   	   "You have not implemented the austerity measures quickly enough.\n"+
			                   "Most bondholders have lost patience, and are now suing the government.\n"+
			                   "The utility's credit rating has dropped yet again.\n"+
			                   "We will have a harder time getting loans to operate with."			                      
			                  );
		
		
	//------2.News Briefs, also Distress messages----------
		

			//positive messages here.
			newsBriefs.Add(statusType.STATE_POSITIVE, 
			                  new string[] {
									"San Juan City turns off all decorative fountains during the drought period.\n",
			               			"Police report several cases of drought-related theft in the southern region.\n",
									"School days in 332 public schools are shortened to cope with drought.\n",
									"Subscribers in dry, rural communities move in with friends or family members "+
									"that have a more regular access to water.\n"
									
									}
		
			                   
			                   );
			     
			//average messages here.
			newsBriefs.Add(statusType.STATE_AVERAGE, 
		               new string[] {  
									"5 subscribers have been arrested for stealing water since 2013 in the Caguas region.\n",
									"Local coffee growers report a loss of 20-25% of their crops.\n"
                                      }                                       			                      			                                         			                                                            			                      			                                         			                   
		             
								);
			
			
			newsBriefs.Add(statusType.STATE_TOUGH,
		               new string[] {  
		                   			"33 out of 78 municipalities have just been designated as disaster zones by the Federal Department of Agriculture.\n",
		               	   			"Forest fires this week have claimed around 10 hectares of natural reserve land.\n"
		               				}
		                   );            
		
		

		
		
		
	}	//end of setup Dictionary();

}
