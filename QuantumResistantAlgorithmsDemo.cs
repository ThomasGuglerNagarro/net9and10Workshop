using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp9;

/// <summary>
/// KMAC Algorithm, ChaCha20-Poly1305, and HashData
/// .NET 9 extends its support for modern cryptographic algorithms, introducing KMAC and ChaCha20-Poly1305.
/// These algorithms offer fast and secure encryption, especially useful for mobile applications, IoT,
/// and other environments where performance is critical.
/// </summary>
public static class QuantumResistantAlgorithmsDemo
{
    internal static void Demo2()
    {
        // new HashData method simplifies the creation of secure hashes:
        // It replaces the previous Create and ComputeHash methods, making it easier to generate hashes directly from byte arrays or strings.
        byte[] hash = SHA256.HashData(Encoding.UTF8.GetBytes("secure data"));
        Console.WriteLine(Convert.ToBase64String(hash));
    }

    internal static void Demo()
    {
        using var chacha20 = new ChaCha20Poly1305(Encoding.UTF8.GetBytes("key"));
        chacha20.Encrypt(
            Encoding.UTF8.GetBytes("nounce"), 
            Encoding.UTF8.GetBytes("plaintext"),
            Encoding.UTF8.GetBytes("associatedData"),
            Encoding.UTF8.GetBytes("tag"));
        /*
        var parameters = new KyberEncryptionParameters(securityLevel: 3);
        using var kyber = new Kyber(parameters);

        var (publicKey, privateKey) = kyber.GenerateKeyPair();

        byte[] ciphertext = kyber.Encrypt(publicKey, Encoding.UTF8.GetBytes("Hello .NET 9!"));

        byte[] plaintext = kyber.Decrypt(privateKey, ciphertext);*/
    }
}
