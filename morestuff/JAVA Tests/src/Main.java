import java.sql.Connection;
import java.sql.DriverManager;
import java.sql.ResultSet;
import java.sql.SQLException;
import java.sql.Statement;
import com.microsoft.sqlserver.jdbc.SQLServerDriver;


public class Main {
	
    public static void main(String[] args) {
    	
    	// note that DESKTOP-HU1540P\\MSSQLSERVER01 should be DESKTOP-HU1540P\MSSQLSERVER01 in other places
    	// create a designated user with permission in MSSQL click on the connection and go to Security folder, add new Login with all the sysadmin certs
    	// in Sql Server Configuration make go to SQL Server Network config and -> protocols and enable TCP/IP, right click properties and 
    	// under IP 23 leave TCP dynamic ports blank and specify port 1433, also all down and enable the IP and active
    	// restart service and make sure the process ID of the sql service is listen on port 1433 using netstat -aon | find /i "listening" | find "<PID>"
    	// should work.
    	// you can play with the connection string using the  Eclipse -> Window -> Presoective Open prespective others Database Development (if you dont have it Help->install new software) and create new database and keep pinging the url
    	// also note that you need to add the C:\Program Files\Java\sqljdbc_11.2\enu\mssql-jdbc-11.2.0.jre8.jar into the Java project in properties
    	// Libraries -> add External JAR 
    	
    	
    	// maybe it doesnt do anything BUT:
    	// also dont forget to add to path: C:\Program Files\Java\sqljdbc_11.2\enu AND C:\Program Files\Java\sqljdbc_11.2\enu\auth\x64
    	// and also copy C:\Program Files\Java\sqljdbc_11.2\enu\auth\x64\mssql-jdbc_auth-11.2.0.x64.dll into the bin folders of the JDK/bin JRE/bin
    	String connectionUrl = "jdbc:sqlserver://DESKTOP-HU1540P\\MSSQLSERVER01:1433;DatabaseName=TestsDB;encrypt=true;trustServerCertificate=true;user=elpashuto;password=qx4321";

    	try {
    	    System.out.print("Connecting to SQL Server ... ");
    	    try (Connection connection = DriverManager.getConnection(connectionUrl))        {
    	        System.out.println("Done.");
    	    }
    	} catch (Exception e) {
    	    System.out.println();
    	    e.printStackTrace();
    	}
    }
    

}
