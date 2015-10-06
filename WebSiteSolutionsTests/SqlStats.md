#Sql Statistics

Total = @Model.Total
<table>
    <th>
        <tr>
            <td>Name</td>
            <td>Median</td>
            <td>Average</td>
            <td>Min</td>
            <td>Max  </td>
            <td>90% under  </td>
        </tr>
    </th>
    @Each.List
    <tr>
        <td> @Current.Key</td>
        <td> @Current.Median</td>
        <td> @Current.Avg</td>
        <td> @Current.Min</td>
        <td> @Current.Max</td>
        <td> @Current.P90</td>
    </tr>
    @EndEach
</table>

---
## help

**ConnectionTime**: 
The amount of time (in milliseconds) that the connection has been opened after statistics have been enabled (total connection time if statistics were enabled before opening the connection).

**ExecutionTime**:
Returns the cumulative amount of time (in milliseconds) that the provider has spent processing once statistics have been enabled, including the time spent waiting for replies from the server as well as the time spent executing code in the provider itself.

**NetworkServerTime**:
Returns the cumulative amount of time (in milliseconds) that the provider spent waiting for replies from the server once the application has started using the provider and has enabled statistics.




