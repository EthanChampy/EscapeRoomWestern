//
// PovRay scene file for a key. 
//
// Author:   Hj. Malthaner
// Email:    hansjoerg.malthaner@gmx.de
// Creation: 30-Dec-09
// Update:   30-Dec-09
//
// Web:      http://opengameart.org/users/varkalandar
//
// This file is available under the GNU general
// public license v2 or newer.
//
// http://www.gnu.org/licenses/gpl-2.0.html
//

global_settings {
	max_trace_level 35
}

#declare Cam1 = camera {
 	orthographic
	location < 2.5, 2.5*0.82, 2.5 >*1.4
	look_at < 0, 0, 0 >
}            

camera { 
	Cam1 
}          

light_source { 
	< 2.5*20, 100, 2.5*10 >
	color rgb < 1, 1, 1 > 
}

// sky sphere

sphere {
	<0,0,0>, 10000

	hollow

	pigment {
      		color rgb 1
	}
}	

#declare FM = 3.0;

#declare FLOOR = box {
	<-1*FM, -0.0, -1*FM>,
	<1*FM, -0.3, 1*FM>

	texture {
      		pigment{
                
 	           	marble
      	      		turbulence 0.7
            		scale 0.02
            
	            	// Earth/Sand
      	      		color_map {
            			[0.0 color <35/255, 30/255, 45/255>] 
                  		[0.2 color <95/255, 80/255, 50/255>] 
    	                  	[0.75 color <110/255, 95/255, 60/255>]
      	            		[0.85 color <155/255, 140/255, 80/255>]
            	      		[1.0 color <180/255, 180/255, 180/255>]
            		}
            
            		quick_color rgb 1
        	}

        	normal {
            		bumps 0.2
            		scale 0.02                
        	}

        	finish {
   			ambient 0.2
		}
	}
}


#declare T_RUSTY_IRON_METAL = material {

    texture
    {
        pigment {
                color rgb <0.56, 0.55, 0.54>
                quick_color rgb <0.6, 0.55, 0.5>
        }
        
        normal {
                bumps 0.03
                scale 0.1
        }
        
        finish {
                ambient 0.15
                diffuse 0.5
        
                specular 1.5
                roughness 0.08
                reflection 0.05
                metallic
        }
    }


    texture
    {
        pigment {
                bozo
                color_map {
                        [0.2 color rgbt <0.6, 0.55, 0.5, 1>]
                        [0.6 color rgbt <0.7, 0.45, 0.4, 0>]
                }
                         
                turbulence 1
                scale 0.3
        }
        
        normal {
                granite 0.6
                scale 0.2
        }      
    }
}


#declare KEY = union {

        torus {
                0.5, 0.1
                translate <0, 0.1, 0>
        }

        cylinder {
                <0.5, 0.1, 0>, <3-0.1*0.4, 0.1, 0>, 0.1
        }
         
        sphere {
                <0,0,0>, 0.1
                scale <0.4, 1, 1>
                translate <3-0.1*0.4, 0.1, 0>
        }
        
        
        // beard
        box {
                <2.1, 0+0.02, -0.5>
                <2.3, 0.2-0.02, 0>
        }
        box {
                <2.3, 0+0.02, -0.3>
                <2.5, 0.2-0.02, 0>
        }
        box {
                <2.5, 0+0.02, -0.4>
                <2.7, 0.2-0.02, 0>
        }
        

	material {
		T_RUSTY_IRON_METAL
	}
}



union {
	object {
		KEY
		rotate <0, 0, -90>
		rotate <0, -30, 0>
		translate <-0.5, 3, -0.5>
	}
	object {
		KEY
		translate <-1, 0, 1>
	}

	object {
		FLOOR
	}
    
	translate <0, -1, 0>
}
